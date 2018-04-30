cmake_minimum_required(VERSION 3.9)
project(FTR_CodingTest)

set(CMAKE_CXX_STANDARD 14)
SET(CMAKE_CXX_FLAGS -pthread) # p-lpthread for gcc; ignored in windows.

# Generate actual application.
add_executable(FTR_CodingTest
        main.cpp
        FrequencyTicker.cpp
        FrequencyTicker.h
        )

# Generate unit test executable.
add_executable(FTR_UnitTests
        FTR_CodingTest_UnitTests.cpp
        FrequencyTicker.cpp
        FrequencyTicker.h
        )

# Copy fibonacci lookup file to output directory.
if(WIN32)
	add_custom_command(
        TARGET FTR_CodingTest POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy
        ${CMAKE_SOURCE_DIR}/fibonacci_sequence_first_1000_values.txt
        ${CMAKE_CURRENT_BINARY_DIR}/Debug/fibonacci_sequence_first_1000_values.txt)
	
	add_custom_command(
        TARGET FTR_UnitTests POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy
        ${CMAKE_SOURCE_DIR}/fibonacci_sequence_first_1000_values.txt
        ${CMAKE_CURRENT_BINARY_DIR}/Debug/fibonacci_sequence_first_1000_values.txt)
else()
	add_custom_command(
        TARGET FTR_CodingTest POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy
        ${CMAKE_SOURCE_DIR}/fibonacci_sequence_first_1000_values.txt
        ${CMAKE_CURRENT_BINARY_DIR}/fibonacci_sequence_first_1000_values.txt)
endif()
