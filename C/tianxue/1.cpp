#include <stdio.h>
#include <math.h>
using namespace std;

int main()
{
	int n;
	scanf("%d",&n);
	//for
	long result;
	int i;
	for (i = 1; i <= n; i++)
	{
		result += pow(i,2);
	}
	//do-while
	long result2;
	int j = 1;
	do
	{
		result2 += pow(j,2);
		j++;
	}
	while(j <= n);
	//while
	long result3;
	int k = 1;
	while (k <= n)
	{
		result3 += pow(k,2);
		k++;
	}
	printf("%d %d %d",result,result2,result3);
	return 0;
}