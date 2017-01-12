#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
#include <sstream>

using namespace std;

const bool debug = false;

const size_t MIN_LINES = 1;
const size_t MAX_LINES = 1000;
const size_t MIN_POINT_COORD = 1;
const size_t MAX_POINT_COORD = 10000000000000000000;
struct Delta {
    public:
        int dx;
        int dy;
        //Delta(const Point& p, const Point& q) {
        //    dx = q.x - p.x;
        //    dy = q.y - p.y;
        //}
        Delta(const int px, const int py, const int qx, const int qy) {
            dx = qx - px;
            dy = qy - py;
        }
        string ToString() const {
            stringstream ss;
            ss << dx << " " << dy;
            return ss.str();
        }
        void Dump() { cout << this->ToString() << endl; }
};

class Point {
    public:
        int x;
        int y;

        Point(int _x = 0, int _y = 0) : x(_x), y(_y) {}
        Point(const Point& rhs) {
            this->x = rhs.x;
            this->y = rhs.y;
        }
        Point& operator=(const Point& rhs) {
            this->x = rhs.x;
            this->y = rhs.y;
            return *this;
        }
        bool Equal(const Point& val) {
            return ((this->x == val.x) && (this->y == val.y));
        }
        string ToString() const {
            stringstream ss;
            ss << x << " " << y;
            return ss.str();
        }
        void Dump() { cout << this->ToString() << endl; }
};

// perform move based on the current state;
// state reflects which move we are performing
class Mover {
public:
    int state;
    int direction;
    static const int MAX_STATE = 4;

    Mover() : state(0), direction(1) {}
    void Next() {
        state = (state +1) % MAX_STATE;
        direction = direction * -1;
    }

    Point Move(const Point& pt) {
        Point result;
        int v = pt.x + (pt.y * direction);
        switch (state) {
            case 0:
            case 1:
                result.x = v;
                result.y = pt.y;
                break;
            case 2:
            case 3:
                result.x = pt.x;
                result.y = v;
                break;
        }
        this->Next();
        return result;
    }
    void Reset() {
        state = 0;
        direction = 1;
    }
};

class Monster {
public:

    Point current;
    Point destination;

    int direction;
    Mover mover;

public:
    Monster(const Point& from, const Point& to ) : current(from), destination(to), direction(1) {}

};

class Move_Manager {
public:
    Move_Manager(const Point& from, const Point& to ) {}

};
int main()
{
    /* Enter your code here. Read input from STDIN. Print output to STDOUT */
    try {
        string input;
        getline(cin, input);
        int count = atoi(input.c_str());

        if (MIN_LINES > count || MAX_LINES < count) {
            cerr << "count of lines out of range " << count << endl;
        }
        vector<int> coord;
        string tmp;

        for (int i=0; i < count; ++i) {
            getline(cin, input);
            if (debug) {
                cout << "input " << input << endl;
            }

            stringstream ss(input);
            while (getline(ss, tmp, ' ')) {
                coord.push_back(atoi(tmp.c_str()));
            }
            if (coord.size() != 4) {
                cerr << "invalid input " << input << endl;
            }
            if ((coord[0] < MIN_POINT_COORD) ||
                (coord[1] < MIN_POINT_COORD) ||
                (coord[2] < MIN_POINT_COORD) ||
                (coord[3] < MIN_POINT_COORD) ) {
                cerr << "input out of range " << "value < " << MIN_POINT_COORD << endl;
            }
            if ((coord[0] > MAX_POINT_COORD) ||
                (coord[1] > MAX_POINT_COORD) ||
                (coord[2] > MAX_POINT_COORD) ||
                (coord[3] > MAX_POINT_COORD) ) {
                cerr << "input out of range " << "value > " << MAX_POINT_COORD << endl;
            }
        }
    }
    catch (exception e) {
        cerr << "exception: " << e.what();
    }
    return 0;
}
