#include <stdio.h>
using namespace std;

int main()
{
	char c;
	scanf("%c",&c);
	if (c >= 65 && c <= 90)
	{
		c += 32;
		printf("%c",c);
	}
	else
	{
		printf("%c is NOT a lowerCase character!",c);
	}
	return 0;
}