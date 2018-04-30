#include <iostream>
#include "FrequencyTicker.h"

/**
 * List of fibonacci numbers: https://www.lotterypost.com/thread/250775
 */

/**
 * Display specific message.
 * @param msg Message to display.
 */
void PrintMessage(const std::string &msg)
{
    std::cout << msg.c_str() << std::endl;
}

/**
 * Main application logic.
 * @return Success.
 */
int main()
{
    std::string inputValue;

    FrequencyTicker frequencyTicker;
    frequencyTicker.LoadFibonacciLookupTable();

	const auto secondsPerDisplay = frequencyTicker.ReadFrequencyDisplayTimeInterval();
    frequencyTicker.Start(secondsPerDisplay, PrintMessage);

    frequencyTicker.ReadUserInput("Please enter the first number", inputValue);
    frequencyTicker.AddNewValue(inputValue);

    while(inputValue != "quit")
    {
        frequencyTicker.ReadUserInput("Please enter the next number", inputValue);
        frequencyTicker.AddNewValue(inputValue);
    }

    frequencyTicker.Stop();

    std::cout << "Thanks for playing, press any key to exit." << std::endl;
    std::getchar();

    return 0;
}
