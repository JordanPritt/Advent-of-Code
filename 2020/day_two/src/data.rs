pub struct PasswordData {
    pub char_count_min: i32,
    pub char_count_max: i32,
    pub letter: char,
    pub password: String,
}
impl PasswordData {
    pub fn new(min: i32, max: i32, letter: char, pwd: String) -> Result<Self, String> {
        return Ok(PasswordData {
            char_count_min: min,
            char_count_max: max,
            letter: letter,
            password: pwd,
        });
    }
}
