//
// Created by ren648 on 13/04/18.
//

#pragma once

#include <iostream>
#include <thread>
#include <chrono>
#include <map>
#include <algorithm>
#include <vector>
#include <cctype>
#include <iterator>
#include <set>


using namespace std;

typedef std::chrono::seconds SecondInterval;
typedef std::function<void(const std::string &)> ThreadFunction;

/**
 * Flip the pair's values; key/value to value/key.
 * @tparam K Type of the key.
 * @tparam V Type of the value.
 * @param p Pair to flip (actual key/value pair).
 * @return Flipped pair; becomes value/key.
 */
template<typename K, typename V>
std::pair<V,K> FlipMapPair(const std::pair<K, V> &p)
{
    return std::pair<V,K>(p.second, p.first);
}

/**
 * Flip the entire map specified and return multimap.
 * @tparam K Type of the key.
 * @tparam V Type of the value.
 * @param src Source map to flip values for.
 * @return Multimap containing flipped values.
 */
template<typename K, typename V>
std::multimap<V,K> FlipMap(const std::map<K, V> &src)
{
    std::multimap<V,K> dst;
    std::transform(src.begin(),
                   src.end(),
                   std::inserter(dst, dst.begin()),
                   FlipMapPair<K, V>);
    return dst;
}

/**
 * Ticker thread class, execute requested function at specified time intervals.
 */
class FrequencyTicker
{
private:
    bool _running = false;
    bool _isDisplayingFrequency = true;

    std::thread _th;

    std::map<std::string, int> _frequencyData;

    /**
     * Since the values are so long, have to store them as string
     */
    std::map<std::string, int> _fibonacciData;

private:
    std::string FormatFrequencies();
    void SplitLine(const std::string &readLine, char delimiter, std::vector<std::string> &readElements);
    bool IsNumber(const std::string& s);

public:
    void LoadFibonacciLookupTable();
    void AddNewValue(std::string inputValue);

    int  ReadFrequencyDisplayTimeInterval(void);
    void ReadUserInput(const string msg, string &inputValue);

    std::map<std::string, int> GetFibonacciData() { return _fibonacciData; }
    std::map<std::string, int> GetFrequencyData() { return _frequencyData; }

    void Start(const int &interval, const ThreadFunction &threadFunction);
    void Stop();
};
