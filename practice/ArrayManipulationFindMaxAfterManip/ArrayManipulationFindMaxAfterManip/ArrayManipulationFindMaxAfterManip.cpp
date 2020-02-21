// ArrayManipulationFindMaxAfterManip.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <cstdio>
#include <ostream>
#include <fstream>
#include <algorithm>
#include <vector>
#include <functional>
#include <sstream>
#include <chrono>
//#define _HAS_CXX17
#include <filesystem>

using namespace std;

#define MAS_TEST 1
#include "parseUtil.h"

vector<string> split_string(string);

// Complete the arrayManipulation function below.
long arrayManipulation(int n, vector<vector<int>> operations) {

	long result = 0;
	// 1 make array to run operations on
	cout << "data size " << n << " operation size: " << operations.size() << endl;
	vector<long> workspace(n+1, 0);

	size_t oplimit = operations.size();
#if defined(USE_NESTED_ARRAY)
	for (size_t xop = 0; xop < oplimit; ++xop) {
		//cout << "? " << opi->size() << std::endl;
		//cout << (*opi)[0] << std::endl;
		size_t val = (size_t)operations[xop][2];
		size_t begin = (size_t)operations[xop][0] - 1;
		size_t end = (size_t)operations[xop][1] - 1;
		size_t distance = end - begin;
		size_t theLast = begin + end;
		for (size_t offset = begin; offset <= end; ++offset) {
			workspace[offset] += val;
			if (result < workspace[offset]) {
				result = workspace[offset];
			}
		}
	}
#elif defined(THIS_IS_SAME)
	int minIndex = operations[0][0] -1;
	int maxIndex = 0;
	for (size_t opx = 0; opx < oplimit; opx++) {
		minIndex = min(minIndex, operations[opx][0] - 1);
		maxIndex = max(maxIndex, operations[opx][1] - 1);
		transform(&workspace[(operations[opx][0] - 1)], 
			      &workspace[(operations[opx][1] - 1)], 
			      &workspace[(operations[opx][0] - 1)], 
			std::bind1st(std::plus<int>(), operations[opx][2]));
	}
	// find max
	for (size_t i = minIndex; i <= (size_t)(maxIndex); ++i)
	{
		if (result < workspace[i])
			result = workspace[i];
	}
#else
	for (size_t opx = 0; opx < oplimit; opx++) {
		int lox  = (operations[opx][0] - 1);
		int maxx = (operations[opx][1]);
		int val = operations[opx][2];
		workspace[lox] += val;
		if (maxx < n)
		{
			workspace[maxx] -= val;
		}
	}
	long tmpR = 0;
	for (size_t i = 0; i < n; ++i)
	{
		tmpR += workspace[i];
		if (tmpR > result)
		{
			result = tmpR;
		}
	}
#endif

	return result;
}

void ProcessInput(std::string const & input)
{
	efs::path inpath(input.c_str());
	if (Verbose())
	{
		std::cout << input << std::endl;
		//std::cout << "CWD: " << efs::current_path() << std::endl;
		//demo_exists(inpath);
	}
	if (!get_exists(inpath))
	{
		std::cout << "File: " << input.c_str() << " not found" << std::endl;
	}
	std::ifstream fin(inpath);
	std::string line;
	std::getline(fin, line);
	// measure time to read operations
	std::chrono::steady_clock::time_point begin_read_ops = std::chrono::steady_clock::now();
	//int count = stoi(line.c_str());
	vector<int> param = tokenize_to_int(line, ' ');
	int element_count = param[0];
	int operation_count = param[1];
	vector<string> data(element_count);
	vector< vector< int > > operations(operation_count);
	for (int i = 0; i < operation_count; ++i)
	{
		std::getline(fin, line);
		operations[i] = tokenize_to_int(line, ' ');
	}
	std::chrono::steady_clock::time_point end_read_ops = std::chrono::steady_clock::now();
	std::cout << "Time to read " << operation_count << " operations (sec) = " << (std::chrono::duration_cast<std::chrono::microseconds>(end_read_ops - begin_read_ops).count()) / 1000000.0 << std::endl;

	long result = 0;
	std::chrono::steady_clock::time_point begin_manip = std::chrono::steady_clock::now();
	std::cout << result << std::endl;
	std::cout << std::endl;
	result = arrayManipulation(element_count, operations);
	std::chrono::steady_clock::time_point end_manip= std::chrono::steady_clock::now();
	std::cout << "Time to run " << operation_count << " operations (sec) = " << (std::chrono::duration_cast<std::chrono::microseconds>(end_manip - begin_manip).count()) / 1000000.0 << std::endl;

	if (Verbose()) {
		for (auto const& r : result) {
			std::cout << r << std::endl;
		}
		std::cout << std::endl;
	} 
}

int main()
{
	for (auto& p : efs::directory_iterator("input"))
	{
		string ps = p.path().string();
		ProcessInput(ps);
	}
}
// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
