def main():
    left_list, right_list = [], []
    differences = []
    total_diff = 0
    with open('input.txt') as f:
        while True:
            line = f.readline()
            if not line:
                break
            left, right = line.split("   ")
            left = int(left)
            right = int(right)
            left_list.append(left)
            right_list.append(right)

        sorted_left = sorted(left_list)
        sorted_right = sorted(right_list)
        for i in range(len(sorted_left)):
            differences.append(abs(sorted_left[i] - sorted_right[i]))
        for number in differences:
            total_diff += number
        print(total_diff)



if __name__ == '__main__':
    main()
