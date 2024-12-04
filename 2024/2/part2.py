def main():
    num_safe_reports = 0
    num_lines = 0
    with open('input.txt') as f:
        while True:
            line = f.readline()
            if not line:
                break
            num_lines += 1
            values = list(map(int, line.split(" ")))
            is_safe = check_safe(values)
            if is_safe:
                num_safe_reports += 1
                continue
            for i in range(len(values)):
                values_copy = values.copy()
                values_copy.pop(i)
                is_safe = check_safe(values_copy)
                if is_safe:
                    num_safe_reports += 1
                    break

        print(num_safe_reports)

def check_safe(values):
    MAX_DIFF = 3
    values_len = len(values)
    is_increasing = True
    for i, value in enumerate(values):
        """Last value"""
        if i == values_len - 1:
            return True
        next_value = values[i + 1]
        if i == 0:
            is_increasing = value < next_value
        if value < next_value and not is_increasing:
            return False
        if value > next_value and is_increasing:
            return False
        diff = abs(value - values[i + 1])
        if diff > MAX_DIFF or diff == 0:
            return False
    return True


if __name__ == '__main__':
    main()

