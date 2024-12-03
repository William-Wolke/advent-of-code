def main():
    left_list, right_list = [], []
    scores = {}
    similarity = 0
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

    left_set = set(left_list)
    for num in left_set:
        scores[num] = 0
    for item in right_list:
        if item in scores:
            scores[item] += 1
    for num in left_set:
        similarity += num * scores[num]
    print(similarity)

if __name__ == '__main__':
    main()
