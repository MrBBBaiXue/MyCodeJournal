#include <stdio.h>
#define LEN 10
using namespace std;

void Input(int *p);
int FindMax(int *p);
int FindMin(int *p);
void Swap(int *p, int a, int b);
void Output(int *p);

int main()
{
	int arr[LEN];
	int *p = arr;
	printf("Input array : ");
	Input(p);
	Swap(p,FindMax(p),LEN - 1);
	Swap(p,FindMin(p),0);
	Output(p);
	return 0;
}

void Input(int *p)
{
	for (int i = 0; i <= LEN - 1; i++)
	{
		scanf("%d",(p + i));
	}
	return;
}

int FindMax(int *p)
{
	int max = *p, maxPos = 0;
	for (int i = 0; i <= LEN - 1; i++)
	{
		maxPos = (*(p + i) > max) ? i : maxPos;
		max = (*(p + i) > max) ? *(p + i) : max;
	}
	return maxPos;
}

int FindMin(int *p)
{
	int min = *p, minPos = 0;
	for (int i = 0; i <= LEN - 1; i++)
	{
		minPos = (*(p + i) < min) ? i : minPos;
		min = (*(p + i) < min) ? *(p + i) : min;
	}
	return minPos;
}

void Swap(int *p, int a, int b)
{
	int t;
	t = *(p + a);
	*(p + a) = *(p + b);
	*(p + b) = t;
	return;
}

void Output(int *p)
{
	for (int i = 0; i <= LEN - 1; i++)
	{
		printf("%d ",*(p + i));
	}
	return;
}