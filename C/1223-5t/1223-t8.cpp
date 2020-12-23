#include <stdio.h>
#include <string.h>
#define MAXN 1000
using namespace std;

int main()
{
	printf("Input String :");
	char arr[MAXN], *p;
	gets(arr);
	p = arr;
	int upperLetters,lowerLetters,numbers,spaces,others;
	upperLetters = lowerLetters = numbers = spaces = others = 0;
	while (*p != '\0')
	{
		if (*p >= 65 && *p <= 90)
		{
			upperLetters++;
		}
		else if (*p >= 97 && *p <= 122)
		{
			lowerLetters++;
		}
		else if (*p >= 49 && *p <= 57)
		{
			numbers++;
		}
		else if (*p == ' ')
		{
			spaces++;
		}
		else
		{
			others++;
		}
		p++;
	}
	printf("\nA-Z : %d\n",upperLetters);
	printf("a-z : %d\n",lowerLetters);
	printf("1-9 : %d\n",numbers);
	printf("Space : %d\n",spaces);
	printf("Others : %d\n",others);
	return 0;
}