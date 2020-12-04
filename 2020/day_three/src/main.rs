use std::{fs::File, io::prelude::*, io::BufReader};

fn main() {
    let map = load_input("C:\\Development\\Advent-of-Code\\2020\\day_three\\input.txt");

    let slopes = [(1, 1), (1, 3), (1, 5), (1, 7), (2, 1)];
    let count: usize = slopes
        .iter()
        .map(|&slope| run_slope(map.iter(), slope))
        .product();

    print!("slope: {}", count);
}

fn run_slope<'a>(
    iterator: impl Iterator<Item = &'a (usize, String)>,
    (rise, run): (usize, usize),
) -> usize {
    iterator
        .step_by(rise)
        .filter(|(lineno, line)| line.chars().cycle().nth(lineno / rise * run).unwrap() == '#')
        .count()
}

fn load_input(file_path: &str) -> Vec<(usize, String)> {
    let file = File::open(file_path).expect("file wasn't found.");
    let reader = BufReader::new(file);
    return reader.lines().flatten().enumerate().collect();
}
