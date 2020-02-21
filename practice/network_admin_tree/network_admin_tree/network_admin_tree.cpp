// network_admin_tree.cpp : This file contains the 'main' function. Program execution begins and ends there.
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
//#include <filesystem>

using namespace std;

#define MAS_TEST 1
#include "parseUtil.h"
vector<string> split_string(string);

// Complete the solve function below.
vector<string> solve(int s, int a, vector<vector<int>> links, vector<vector<int>> queries) {
	vector<string> result;


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
	// read S.L.A.T.
	std::getline(fin, line);
	// measure time to read operations
	std::chrono::steady_clock::time_point begin_rl = std::chrono::steady_clock::now();
	//int count = stoi(line.c_str());
	vector<int> param = tokenize_to_int(line, ' ');
	size_t server_count = (size_t)param[0];
	size_t link_count = (size_t)param[1];
	size_t admin_count = (size_t)param[2];
	size_t t_operation_count = (size_t)param[3];

	// ***********************
	// READ LINKS
	// ***********************
	vector< vector< int > > links(link_count);
	for (size_t l = 0; l < link_count; ++l) {
		std::getline(fin, line);
		links[l] = tokenize_to_int(line, ' ');
	}
	vector<string> data(element_count);
	vector< vector< int > > operations(operation_count);
	for (int i = 0; i < operation_count; ++i)
	{
		std::getline(fin, line);
		operations[i] = tokenize_to_int(line, ' ');
	}

	long operation_count = 0;
	// start reading operation data
	std::chrono::steady_clock::time_point begin_operation_read = std::chrono::steady_clock::now();

	std::chrono::steady_clock::time_point end_operation_read = std::chrono::steady_clock::now();
	std::cout << "Time to run " << operation_count << " operations (sec) = " << (std::chrono::duration_cast<std::chrono::microseconds>(end_operation_read - begin_operation_read).count()) / 1000000.0 << std::endl;

	vector<string> result;
	std::chrono::steady_clock::time_point begin_manip = std::chrono::steady_clock::now();

	if (Verbose()) {
		for (auto const& r : result) {
			std::cout << r << std::endl;
		}
		std::cout << std::endl;
	}
}

int main()
{
	// my program will cycle through all files in the ./input folder
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
