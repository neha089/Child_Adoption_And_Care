// Online C++ compiler to run C++ program online
#include <iostream>
#include<bits/stdc++.h>
using namespace std;\
int check(string s,int n,vector<string> str,int j)
{
    int c=0;
    for(int i=0;i<n;i++)
    {
        string s1=str[i].substr(0,j);
        if(s==s1)
         c++;
    }
    return c;
}
int main() {
    int n;
    cin>>n;
    vector<string> str(n);
    for(int i=0;i<n;i++)
    {
        cin>>str[i];
    }
    vector<int> prefix(n,0);
    for(int i=0;i<n;i++)
    {
        int l=str[i].size();
        for(int j=1;j<=l;j++)
        {
            string s=str[i].substr(0,j);
            prefix[i]+=check(s,n,str,j);
        }
    }
    for(int i=0;i<n;i++)
        cout<<prefix[i]<<endl;
    return 0;
}