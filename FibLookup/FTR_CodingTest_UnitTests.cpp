//
// Created by ren648 on 16/04/18.
//

#define CATCH_CONFIG_MAIN  // This tells Catch to provide a main() - only do this in one cpp file.
#include "catch.hpp" // Include unit testing library.

#include "FrequencyTicker.h"

TEST_CASE("Test fibonacci numbers lookup table", "[Fib]")
{
    FrequencyTicker frequencyTicker;
    frequencyTicker.LoadFibonacciLookupTable();

    auto fibLookupTable = frequencyTicker.GetFibonacciData();

    REQUIRE(999 == fibLookupTable.size());
    REQUIRE(8 == fibLookupTable["13"]);
}

TEST_CASE("Test adding new value to frequency table", "[Freq]")
{
    string newValue = "11";

    FrequencyTicker frequencyTicker;
    frequencyTicker.LoadFibonacciLookupTable();

    frequencyTicker.AddNewValue(newValue);
    frequencyTicker.AddNewValue("qq"); // Shouldn't be able to add characters.

    auto frequencyData = frequencyTicker.GetFrequencyData();

    REQUIRE(1 == frequencyData.size());
    REQUIRE(1 == frequencyData[newValue]);

    frequencyTicker.AddNewValue(newValue);
    frequencyData = frequencyTicker.GetFrequencyData();

    REQUIRE(1 == frequencyData.size());
    REQUIRE(2 == frequencyData[newValue]);
}

TEST_CASE("Test map helper methods", "[Map]")
{
    FrequencyTicker frequencyTicker;
    frequencyTicker.LoadFibonacciLookupTable();

    auto fibLookupTable = frequencyTicker.GetFibonacciData();
    auto flippedMap = FlipMap(fibLookupTable);

    REQUIRE(999 == flippedMap.size());

    REQUIRE(8 == flippedMap.find(8)->first);
    REQUIRE("13" == flippedMap.find(8)->second);

    REQUIRE(8 == fibLookupTable["13"]);
}