mod credentials;

use credentials::PassportCredentials;

fn main() {
    let test = PassportCredentials {
        birth_year: 1900,
        issue_year: 1900,
        exp_year: 2050,
        height: 5.11,
        hair_color: String::from("purple"),
        eye_color: String::from("magenta"),
        passport_id: String::from("1234-b678-1b2c"),
        country_id: String::from("NP-1"),
    };

    println!("Credentials: {}", test);
}
