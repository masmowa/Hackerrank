// arrayCountMatchingString.cpp : This file contains the 'main' function. Program execution begins and ends there.
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
//#define _HAS_CXX17
#include <filesystem>

using namespace std;

#define MAS_TEST 1
#include "parseUtil.h"

// Complete the matchingStrings function below.
/* 
    There is a collection of input strings and a collection of query strings. 
    For each query string, determine how many times it occurs in the list of input strings. 
*/
vector<int> matchingStrings(vector<string> strings, vector<string> queries) {
	vector<int> result;
	int count_match = 0;

	for (auto& q : queries) {
		for (auto& w : strings) {
			if (q.size() == w.size() && q[0] == w[0])
			{
				if (q == w)
					count_match++;
			}
		}
		result.push_back(count_match);
		count_match = 0;
	}

	return result;
}

void ProcessInput(std::string const & input)
{
	efs::path inpath(input.c_str());
	if (Verbose())
	{
		std::cout << input << std::endl;
		//std::cout << "CWD: " << efs::current_path() << std::endl;
		demo_exists(inpath);
	}
	if (!get_exists(inpath))
	{
		std::cout << "File: " << input.c_str() << " not found" << std::endl;
	}
	std::ifstream fin(inpath);
	std::string line;
	std::getline(fin, line);

	int count = stoi(line.c_str());
	vector<string> data;
	for (int i = 0; i < count; ++i)
	{
		std::getline(fin, line);
		data.push_back(line);
	}

	std::getline(fin, line);

	int qcount = stoi(line.c_str());
	vector<string> queries;
	for (int i = 0; i < qcount; ++i)
	{
		std::getline(fin, line);
		queries.push_back(line);
	}
	vector<int> result;
	result = matchingStrings(data, queries);

	for (auto& v : result) {
		std::cout << v << std::endl;
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
