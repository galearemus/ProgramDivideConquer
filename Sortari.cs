using System;
using System.Collections.Generic;
using System.Text;

namespace DivideConquer
{
    //Aceasta clasa detine totalitatea functilor pentru sortarea vectorilor.
    class Sortari
    {
        //Functie de imbinare pentru MergeSort
        private static void Merge(int[] input, int left, int middle, int right)
        {

            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {


                    input[k] = rightArray[j];
                    j++;
                }
            }
        }
        //Functia principala a Sortarii prin imbinare (MergeSort
        public static void MergeSort(int[] input, int left, int right, int dim)
        {

            if (left < right)
            {

                int middle = (left + right) / 2;

                MergeSort(input, left, middle, dim);
                MergeSort(input, middle + 1, right, dim);
                Program.Write(input, dim);
                Merge(input, left, middle, right);
            }
        }
        //Functie recursiva Care Verifica daca un vector este sortat
        //
        public static bool arraySortedOrNot(int[] arr, int n)
        {
            // Vectorul are mai mult de un element
            if (n == 1)
                return true;

            // Verificator elemente Sortate 
            if (arr[n - 1] < arr[n - 2])
                return false;

            // daca s-a ajuns aici inseamna ca perechea este sortata
            // urmatorul pas
            return arraySortedOrNot(arr, n - 1);
        }
        /* Functia principala de Sortare QuickSort
        arr[] --> vector pentru sortare, 
        low --> index pornire, 
        high --> index final */
        public static void QuickSort(int[] arr, int low, int high, int dim)
        {
            if (low < high)
            {


                Program.Write(arr, dim);
                /* pi partitioneaza dupa index, arr[pi] este la locul potrivit*/
                int pi = partition(arr, low, high, dim);

                // sorteaza elementele precedente recursiv 
                // inainte si dupa partitie
                QuickSort(arr, low, pi - 1, dim);
                QuickSort(arr, pi + 1, high, dim);
            }
        }
        //Functie de definire partitie
        private static int partition(int[] arr, int low,
                                   int high, int dim)
        {
            int pivot = arr[high];

            // indexul elementului mai mic
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // Daca elementul este mai mic 
                // decat pivotul
                if (arr[j] < pivot)
                {
                    i++;

                    // schimba arr[i] cu arr[j] 
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // schimba arr[i+1] cu arr[high] (sau element pivot) 
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        public static int BinarySearch(int[] data, int key, int left, int right)
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;
                if (key == data[middle])
                    return middle;
                else if (key < data[middle])
                    return BinarySearch(data, key, left, middle - 1);
                else
                    return BinarySearch(data, key, middle + 1, right);
            }
            return -1;
        }
    }
}
