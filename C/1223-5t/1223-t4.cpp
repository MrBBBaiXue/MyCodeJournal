#include <stdio.h>
#define MAXN 1000
using namespace std;
void MoveArray(int* p, int len, int mov);
int main()
{
	int n, m, arr[MAXN] = { 0 }, * p = arr;
	printf("Input the length of array : ");
	scanf_s("%d", &n);
	printf("Input array data : ");
	for (int i = 0; i <= n - 1; i++)
	{
		scanf_s("%d", (p + i));
	}
	printf("Input how many numbers do you want to move : ");
	scanf_s("%d", &m);
	MoveArray(p, n, m);
	printf("Move result : ");
	for (int i = 0; i <= n - 1; i++)
	{
		printf("%d ", *(p + i));
	}
	return 0;
}

void MoveArray(int* p, int len, int mov)
{
	int endStart = len;
	int endEnd = len + mov - 1;
	for (int i = 1; i <= mov; i++)
	{
		for (int j = len + i - 1; j >= i; j--)
		{
			*(p + j) = *(p + j - 1);
		}
	}
	int j = 0;
	for (int i = endStart; i <= endEnd; i++)
	{
		*(p + j++) = *(p + i);
	}
	return;
}