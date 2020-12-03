use std::{
    fs::File,
    io::{prelude::*, BufReader},
    path::Path,
    time::Instant,
};

fn main() {
    let before = Instant::now();
    let location = Path::new("input.txt");
    let nums = load_from_file(location);

    calculate_pairs(nums);
    println!("Elapsed time: {:.2?}", before.elapsed());
}

fn calculate_pairs(numbers: Vec<i64>) {
    let nums_one = &numbers;
    let nums_two = &numbers;
    let nums_three = &numbers;
    'outer: for num1 in nums_one {
        for num2 in nums_two {
            for num3 in nums_three {
                if num1 + num2 + num3 == 2020 {
                    let result = num1 * num2 * num3;
                    println!("{}", result);
                    break 'outer;
                }
            }
        }
    }
}

fn load_from_file(file_path: &Path) -> Vec<i64> {
    let file = File::open(file_path).expect("file wasn't found.");
    let reader = BufReader::new(file);

    let numbers: Vec<i64> = reader
        .lines()
        .map(|line| line.unwrap().parse::<i64>().unwrap())
        .collect();

    return numbers;
}
