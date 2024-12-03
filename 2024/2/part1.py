
def main():
    num_safe_reports = 0
    num_lines = 0
    MAX_DIFF = 3
    with open('input.txt') as f:
        while True:
            line = f.readline()
            if not line:
                break
            num_lines += 1
            values = list(map(int, line.split(" ")))
            values_len = len(values)
            is_increasing = True
            for i, value in enumerate(values):
                if i == values_len - 1:
                    num_safe_reports += 1
                    continue
                next_value = values[i + 1]
                if i == 0:
                    is_increasing = value < next_value
                if value < next_value and not is_increasing:
                    break
                if value > next_value and is_increasing:
                    break
                diff = abs(value - values[i + 1])
                if diff > MAX_DIFF or diff == 0:
                    break

        print(num_safe_reports)

if __name__ == '__main__':
    main()
