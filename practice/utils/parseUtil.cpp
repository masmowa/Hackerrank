#include <iostream>
#include <string>
#include <cstdio>
#include <ostream>
#include <fstream>
#include <algorithm>
#include <vector>
#include <functional>
#include <sstream>

#include <filesystem>
//namespace fs = std::filesystem;

#include <experimental/filesystem>
namespace efs = std::experimental::filesystem;
#include "parseUtil.h"

using namespace std;



vector<string> tokenize(std::string const &line, char delim)
{
	std::string token;
	vector<string> out;

	std::istringstream stm(line);

	while (std::getline(stm, token, delim))
	{
		out.push_back(token);
	}
	return out;
}

std::vector<int> tokenize_to_int(std::string const &line, char delim)
{
	std::vector<int> out;

	std::istringstream stm(line);
	std::string token;

	while (std::getline(stm, token, delim))
	{
		out.push_back(std::atoi(token.c_str()));
	}
	return out;
}

void demo_exists(efs::path& p, efs::file_status s = efs::file_status{}) {
	std::cout << p;
	bool bexist = efs::status_known(s) ? efs::exists(s) : efs::exists(p);

	if (Verbose()) {
		if (bexist) {
			std::cout << " Exists\n";
		}
		else {
			std::cout << " does not Exist\n";
		}
	}
}

bool read_array_lines(efs::path& p, std::vector<std::string>& result)
{
	bool res = true;
	std::ifstream in(p);
	if (!in) {
		std::cerr << "Cannot open the File : " << p << std::endl;
		return false;
	}
	std::string line;
	while (std::getline(in, line))
	{
		if (line.size() > 0)
		{
			result.push_back(line);
		}
	}
	in.close();

	return res;
}

void print_lines(std::vector<string> &v) {

	for (auto const& val : v)
	{
		std::cout << val << std::endl;
	}
}

