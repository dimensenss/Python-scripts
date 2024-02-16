import random
from statistics import mean
from collections import Counter

import seaborn as sns
from matplotlib import pyplot as plt


def random_select(boxes, prisoner_number):
    random_select_numbers = list(range(100))
    random.shuffle(random_select_numbers)

    for i in range(50):
        if boxes[random_select_numbers[i]] == prisoner_number:
            return 1


def strategy_select(boxes, prisoner_number):
    prisoner_select = prisoner_number
    for _ in range(50):
        if boxes[prisoner_select] == prisoner_number:
            return 1
        else:
            prisoner_select = boxes[prisoner_select]


if __name__ == '__main__':
    total_simulations = 10
    simulations_per_experiment = 100
    success_list = []

    for _ in range(total_simulations):
        local_success = 0

        for _ in range(simulations_per_experiment):
            boxes = list(range(100))
            random.shuffle(boxes)

            prisoner_numbers = list(range(100))

            success_prisoner = 0

            for j in range(100):
                if strategy_select(boxes, prisoner_numbers[j]):
                    success_prisoner += 1

            if success_prisoner == len(boxes):
                local_success += 1

        success_list.append(local_success)

    print(mean(success_list), '%')
