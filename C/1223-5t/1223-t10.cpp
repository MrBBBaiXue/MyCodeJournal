#include <stdio.h>
#define SIZE 5
using namespace std;

void Sort(int *p,int len);

int main()
{
	int mtx[SIZE][SIZE] = {
        {1,2,3,4,5},
        {6,7,8,9,10},
        {11,12,13,14,15},
        {16,17,18,19,20},
        {21,22,23,24,25}
    };
    int buffer[SIZE*SIZE], (*p)[SIZE] = mtx, *q = buffer;
    for (int i = 0; i <= SIZE - 1; i++)
    {
    	for (int j = 0; j <= SIZE - 1; j++)
        {
            *q = *( *(p + i) + j );
            *( *(p + i) + j ) = -1;
            *q++;
        }
    }
    q = buffer;
    Sort(q,SIZE);
    *(*(p + 0) + 0) = *q++;
    *(*(p + 0) + SIZE - 1) = *q++;
    *(*(p + SIZE - 1) + 0) = *q++;
    *(*(p + SIZE - 1) + SIZE - 1) = *q++;
    *(*(p + SIZE / 2) + SIZE / 2) = *(q + 20);
    for (int i = 0; i <= SIZE - 1; i++)
    {
    	for (int j = 0; j <= SIZE - 1; j++)
    	{
    		if (*(*(p + i) + j) == -1)
    		{
    			*( *(p + i) + j ) = *q++;
			}
		}
	}
	//output
	for (int i = 0; i <= SIZE - 1; i++)
    {
    	for (int j = 0; j <= SIZE - 1; j++)
    	{
    		printf("%4d",*( *(p + i) + j ));
		}
		printf("\n");
	}
	return 0;
}

void Sort(int *p,int len)
{
    for (int i = 0; i <= len - 1; i++)
    {
        for (int j = i; j <= len - 1; j++)
        {
            if (*(p + i) > *(p + j))
            {
                int t;
                t = *(p + i);
                *(p + i) = *(p + j);
                *(p + j) = t;
            }
        }
    }
    return;
}
