// Dynamic2dArrayXor.cpp : This file contains the 'main' function. Program execution begins and ends there.
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

/* from:
https://www.hackerrank.com/challenges/dynamic-array/problem?h_r=next-challenge&h_v=zen
*/
/*
 * Complete the 'dynamicArray' function below.
 *
 * The function is expected to return an INTEGER_ARRAY.
 * The function accepts following parameters:
 *  1. INTEGER n
 *  2. 2D_INTEGER_ARRAY queries
 */

vector<int> dynamicArray(int n, vector<vector<int>> queries) {
	std::vector<int> result;
	int lastAnswer = 0;
	std::vector < std::vector<int> > sequences(n);

	if (Verbose()) {
		cout << "dynamicArray ( " << n << " ...)" << std::endl;

		print_2d_vector<int>(queries);
	}
	for (size_t i = 0; i < queries.size(); ++i)
	{
		// Action Type
		int at = queries[i][0];
		int x = queries[i][1];
		int y = queries[i][2];
		std::cout << "Action type " << at << " x " << x << " y " << y << std::endl;
		if (at == 1) {
			int sequenceIndex = (x ^ lastAnswer) % n;
			if (Verbose()) {
				std::cout <<  " sequence[ " << sequenceIndex << "] << " << y << std::endl;
			}
			sequences[sequenceIndex].push_back(y);
		}
		if (at == 2)
		{
			int sequenceIndex = (x ^ lastAnswer) % n;
			if (Verbose()) {
				std::cout << " lastAnswer " << lastAnswer << " << ";
			}
			int valueIndex = (y % sequences[sequenceIndex].size());
			int oldLastAnswer = lastAnswer;
			lastAnswer = sequences[sequenceIndex][valueIndex];
			if (Verbose()) {

				std::cout << " sequence[" << sequenceIndex << "][" << valueIndex << "]" << " lastAnswer " << lastAnswer << std::endl;
			}

			result.push_back(lastAnswer);
		}

	}
	return result;
}

string ltrim(const string &str) {
	string s(str);

	s.erase(
		s.begin(),
		find_if(s.begin(), s.end(), not1(ptr_fun<int, int>(isspace)))
	);

	return s;
}

string rtrim(const string &str) {
	string s(str);

	s.erase(
		find_if(s.rbegin(), s.rend(), not1(ptr_fun<int, int>(isspace))).base(),
		s.end()
	);

	return s;
}

vector<string> split(const string &str) {
	vector<string> tokens;

	string::size_type start = 0;
	string::size_type end = 0;

	while ((end = str.find(" ", start)) != string::npos) {
		tokens.push_back(str.substr(start, end - start));

		start = end + 1;
	}

	tokens.push_back(str.substr(start));

	return tokens;
}



int main()
{
    //std::cout << "Hello World!\n";
	efs::path base("D:/Users/Mark/Documents/GitHub/Hackerrank/practice/Dynamic2dArrayXor/Dynamic2dArrayXor/input");
	//efs::path inputFileName("input10.txt");
	efs::path inputFileName("input00.txt");
	efs::path full_path = base / inputFileName;
	if (Verbose())
	{
		std::cout << full_path << std::endl;
	}

	std::ifstream fin(full_path);
	std::string line;

	std::getline(fin, line);

	std::vector<int> conditions = tokenize_to_int(line, ' ');
	// count of sequence
	int n = conditions[0];
	// count of steps
	int q = conditions[1];

	vector < vector<int>> queries(q);
	for (int i = 0; i < q; i++) {
		queries[i].resize(3);

		string queries_row_temp_temp;
		getline(fin, queries_row_temp_temp);

		vector<int> temp_q = tokenize_to_int(queries_row_temp_temp, ' ');
		for (size_t j = 0; j < temp_q.size(); ++j) {
			queries[i][j] = temp_q[j];
		}
	}
	fin.close();
	vector<int> result = dynamicArray(n, queries);

	for (size_t i = 0; i < result.size(); i++) {
		cout << result[i];

		if (i != result.size() - 1) {
			std::cout << "\n";
		}
	}

	std::cout << "\n";

	return 0;
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
