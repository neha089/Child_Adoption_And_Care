package leetcode.easy;

import java.util.ArrayList;

/*
Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Example 1:
Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0

Example 2:
Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 */
public class FindIndexOfFistOcuuString {

    public static void main(String[] args) {
        System.out.println(strStr("sadbutsad", "sad"));
    }

    public static int strStr(String haystack, String needle) {
        int lastIndex = 0;
        ArrayList<Integer> getIndex = new ArrayList<>();
        while (lastIndex != -1) {
            lastIndex = haystack.indexOf(needle, lastIndex);
            if (lastIndex != -1) {
                getIndex.add(lastIndex);
                lastIndex = lastIndex + needle.length();
            }
        }
        if (getIndex.size() > 0) {
            return getIndex.get(0);
        } else {
            return lastIndex;
        }
    }
}
