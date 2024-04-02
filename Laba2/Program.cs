using System;
using System.Collections.Generic;

class SortingAlgorithms
{
    // 1. Merge Sort
    static void MergeSort(int[] arr)
    {
        if (arr.Length <= 1)
            return;

        int mid = arr.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];

        Array.Copy(arr, 0, left, 0, mid);
        Array.Copy(arr, mid, right, 0, arr.Length - mid);

        MergeSort(left);
        MergeSort(right);

        Merge(arr, left, right);
    }

    static void Merge(int[] arr, int[] left, int[] right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] < right[j])
                arr[k++] = left[i++];
            else
                arr[k++] = right[j++];
        }

        while (i < left.Length)
            arr[k++] = left[i++];

        while (j < right.Length)
            arr[k++] = right[j++];
    }

    // 2. Shaker Sort
    static void ShakerSort(int[] arr)
    {
        bool swapped;
        do
        {
            swapped = false;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                    swapped = true;
                }
            }

            if (!swapped)
                break;

            swapped = false;

            for (int i = arr.Length - 2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                    swapped = true;
                }
            }

        } while (swapped);
    }

    // 3. Bin Research (Binary Search)
    static int BinarySearch(int[] arr, int key)
    {
        int low = 0, high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (arr[mid] == key)
                return mid;

            if (arr[mid] < key)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return -1;
    }

    // 4. Radix Sort
    static void RadixSort(int[] arr)
    {
        int max = MaxValue(arr);

        for (int exp = 1; max / exp > 0; exp *= 10)
            CountSort(arr, exp);
    }

    static void CountSort(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        for (int i = 0; i < 10; i++)
            count[i] = 0;

        for (int i = 0; i < n; i++)
            count[(arr[i] / exp) % 10]++;

        for (int i = 1; i < 10; i++)
            count[i] += count[i - 1];

        for (int i = n - 1; i >= 0; i--)
        {
            output[count[(arr[i] / exp) % 10] - 1] = arr[i];
            count[(arr[i] / exp) % 10]--;
        }

        for (int i = 0; i < n; i++)
            arr[i] = output[i];
    }

    static int MaxValue(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }
        return max;
    }

    // 5. Max Selection
    static void MaxSelectionSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int maxIndex = 0;

            for (int j = 1; j <= i; j++)
            {
                if (arr[j] > arr[maxIndex])
                    maxIndex = j;
            }

            Swap(arr, maxIndex, i);
        }
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Original array: " + string.Join(", ", arr));

        // 1. Merge Sort
        MergeSort(arr);
        Console.WriteLine("Merge Sort: " + string.Join(", ", arr));

        // 2. Shaker Sort
        ShakerSort(arr);
        Console.WriteLine("Shaker Sort: " + string.Join(", ", arr));

        // 3. Bin Research (Binary Search)
        Array.Sort(arr); // Binary Search requires a sorted array
        int key = 22;
        int binSearchResult = BinarySearch(arr, key);
        Console.WriteLine($"Binary Search: Index of {key} is {binSearchResult}");

        // 4. Radix Sort
        RadixSort(arr);
        Console.WriteLine("Radix Sort: " + string.Join(", ", arr));

        // 5. Max Selection
        MaxSelectionSort(arr);
        Console.WriteLine("Max Selection Sort: " + string.Join(", ", arr));
    }
}
