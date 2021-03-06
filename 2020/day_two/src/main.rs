pub mod data;

use data::PasswordData;
use std::{fs::File, io::prelude::*, io::BufReader};

#[macro_use]
extern crate scan_fmt;

fn main() {
    println!("Loading data...");
    let buffer = load_data("C:\\Development\\Advent-of-Code\\2020\\day_two\\input.txt");
    let passwords = parse_lines(buffer);

    println!("parsing data...");

    let count = count_valid(passwords);
    println!("Valid passwords: {}", count);
}

fn count_valid(data: Vec<PasswordData>) -> i32 {
    return data.iter().filter(|pwd| pwd.is_valid()).count() as i32;
}

fn parse_lines(reader: BufReader<std::fs::File>) -> Vec<PasswordData> {
    let data = reader
        .lines()
        .map(|l| {
            let line = l.unwrap();
            let (min, max, character, password) =
                scan_fmt!(&line, "{d}-{d} {}: {}", i32, i32, char, String).expect("Bad format");
            PasswordData {
                char_count_min: min,
                char_count_max: max,
                letter: character,
                password: String::from(password),
            }
        })
        .collect::<Vec<PasswordData>>();
    return data;
}

fn load_data(file_path: &str) -> BufReader<std::fs::File> {
    let file = File::open(file_path).expect("file wasn't found.");
    return BufReader::new(file);
}
