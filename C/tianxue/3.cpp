#include <stdio.h>
using namespace std;

int main()
{
	float s = 0,n = 1;
	while (true)
	{
		int x;
		printf("Input the score of No.%.0f student :",n);
		scanf("%d",&x);
		if (x == -1)
		{
			n--;
			break;
		}
		else
		{
			s += x;
			n++;
		}	
	}
	printf("Average: %.2f",s/n);
	return 0;
}