//
// Created by ren648 on 13/04/18.
//

#include <fstream>
#include <sstream>

#include "FrequencyTicker.h"

void FrequencyTicker::LoadFibonacciLookupTable()
{
    ifstream fibLookupStream("fibonacci_sequence_first_1000_values.txt");

    // Check for input file existence and load lookup table.
    if(fibLookupStream.good())
    {
        std::string readBuffer;
        while(std::getline(fibLookupStream, readBuffer))
        {
            vector<string> rowValues;
            SplitLine(readBuffer, '\t', rowValues);

            // Store values with fibonacci (fib) number as key, and value as fib count.
            int fibIndex = atoi(rowValues[0].c_str());
            _fibonacciData[rowValues[1]] = fibIndex;
        }
    }
}

/**
 * Start thread with specified time interval and thread worker function.
 * @param interval Time interval to call threadFunction in seconds.
 * @param threadFunction Function to execute at the allocated time interval.
 */
void FrequencyTicker::Start(const int &interval, const ThreadFunction &threadFunction)
{
    _running = true;
    _th = thread([=]()
                {
                    while (_running)
                    {
                        if(_isDisplayingFrequency)
                        {
                            // Ensure fast exit when quit is issued.
                            for(int i = 1; i < interval; i++)
                            {
                                if(!_running)
                                    return;

                                this_thread::sleep_for(SecondInterval(1));
                            }

                            // Display formatted frequency data.
                            std::string formattedFrequencies = FormatFrequencies();
                            threadFunction(formattedFrequencies);
                        }
                    }
                });
}

/**
 * Stop the thread, by waiting for its execution to stop.
 */
void FrequencyTicker::Stop()
{
    _running = false;
    _th.join(); // Wait for thread to return.
}

/**
 * Add new value to the map; also counts value frequency.
 * @param inputValue Value to add to the map.
 */
void FrequencyTicker::AddNewValue(std::string inputValue)
{
    bool isExitingFunction = false;
    if(inputValue == "halt")
    {
        _isDisplayingFrequency = false;
        isExitingFunction = true;

        std::cout << "timer halted" << std::endl;
    }
    else if(inputValue == "resume")
    {
        _isDisplayingFrequency = true;
        isExitingFunction = true;

        std::cout << "timer resumed" << std::endl;
    }

    // Ensure that only number type values are added to the lookup table.
    if(!IsNumber(inputValue) || isExitingFunction)
        return;

    // Check if the input value is in the fib lookup table.
    auto isInputValueFibonacci = !(_fibonacciData.find(inputValue) == _fibonacciData.end());
    if(isInputValueFibonacci)
        std::cout << "FIB" << std::endl;

    // Convert inputValue and check for existence in the map.
    _frequencyData.find(inputValue) == _frequencyData.end() ? (_frequencyData[inputValue] = 1)
                                                          : (_frequencyData[inputValue] ++);
}

/**
 * Format frequency data.
 * @return String reprensentation of frequencies.
 */
std::string FrequencyTicker::FormatFrequencies()
{
    std::string retVal;

    // Need to use multimap, because it allows for duplicate values.
    std::multimap<int, string> newMap = FlipMap(_frequencyData);

    // Display sorted list of values according to frequency.
    std::multimap<int, string>::reverse_iterator rit;
    for (rit = newMap.rbegin(); rit != newMap.rend(); ++rit)
        retVal += rit->second + ":" + std::to_string(rit->first) + ",";

    // Return formatted value after removing last comma (,).
    return retVal.substr(0, retVal.size() - 1);
}

/**
 * Split a string on a specified delimiter.
 * @param readLine Input string to split.
 * @param delimiter Delimiter to use to split on.
 * @param readElements Elements generated after a split.
 */
void FrequencyTicker::SplitLine(const std::string &readLine, char delimiter, std::vector<std::string> &readElements)
{
    std::stringstream ss;
    std::string item;

    ss.str(readLine);
    while (std::getline(ss, item, delimiter))
        readElements.push_back(item);
}

/**
 * Check if the specified string only contains numeric values.
 * @param s String constant to check for digits.
 * @return Is value a number? True/False.
 */
bool FrequencyTicker::IsNumber(const std::string& s)
{
    return !s.empty() &&
            std::find_if(s.begin(),
                         s.end(), [](char c)
                         {
                             return !std::isdigit(c);
                         }) == s.end();
}

/**
 * Get user input value for the number of seconds to use for displaying the frequency.
 * @return Number of seconds to wait for displaying frequency, or default to 5 seconds.
 */
int FrequencyTicker::ReadFrequencyDisplayTimeInterval(void)
{
	auto secondsPerDisplay = 5;

    std::cout << "Please input the number of time in seconds between emitting numbers and their frequency" << std::endl;
    cin >> secondsPerDisplay;

    return secondsPerDisplay == 0 ? 5 : secondsPerDisplay;
}

/**
 * Read user input with specified message.
 * @param msg Message to display to user before reading string value.
 * @param inputValue String value read from the user.
 */
void FrequencyTicker::ReadUserInput(const std::string msg, std::string &inputValue)
{
    std::cout << msg << std::endl;
    std::cin >> inputValue;
}
