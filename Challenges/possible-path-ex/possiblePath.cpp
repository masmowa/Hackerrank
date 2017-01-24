#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;


int main() {

    long long testCases;
    long long gcdStart, gcdDestination;
    long long startX, startY, destX, destY, quotient;
    long long remainder = 12345;

    cin >> testCases;

    for ( long long i=0; i < testCases; ++i) {

        cin >> startX >> startY >> destX >> destY;

        while ( remainder != 0 ) 
        {
            remainder = startX % startY;
            startX = startY;
            startY = remainder;
            
            if (remainder == 0) 
            {
                quotient = startX;
            }
        }
        remainder = 12345;
        gcdStart = quotient;

        while ( remainder != 0 ) 
        {

            remainder = destX % destY;
            destX = destY;
            destY = remainder;

            if (remainder == 0) 
            {
                quotient = destX;
            }
        }
        gcdDestination = quotient;

        if (gcdDestination == gcdStart) 
        {
            cout << "YES" << endl;
        }
        else 
        {
            cout << "NO" << endl;
        }
    }
    return 0;
}