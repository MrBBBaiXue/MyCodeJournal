#include <stdio.h>
using namespace std;

void Sort(int *p,int len);

int main()
{
	int mtx[5][5] = {
        {1,2,3,4,5},
        {6,7,8,9,10},
        {11,12,13,14,15},
        {16,17,18,19,20},
        {21,22,23,24,25}
    };
    int buffer[25], *p, *q = buffer;
    for (int i = 0; i <= 4; i++)
    {
        for (int j = 0; j <= 4; j++)
        {
            *q = *(*(p + i) + j);
            *(*(p + i) + j) = -1;
            *q++;
        }
    }
    q = buffer;
    Sort(q,25);
}

void Sort(int *p,int len)
{
    for (int i = 0; i <= len - 1; i++)
    {
        for (int j = i; j <= len - 1; j++)
        {
            
        }
    }
    return;
}
