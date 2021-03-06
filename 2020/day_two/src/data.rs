pub struct PasswordData {
    pub char_count_min: i32,
    pub char_count_max: i32,
    pub letter: char,
    pub password: String,
}
impl PasswordData {
    pub fn new(
        min_count: i32,
        max_count: i32,
        letter_char: char,
        pwd: String,
    ) -> Result<Self, String> {
        return Ok(PasswordData {
            char_count_min: min_count,
            char_count_max: max_count,
            letter: letter_char,
            password: pwd,
        });
    }

    // pub fn is_valid(&self) -> bool {
    //     let occurrences = self.password.matches(self.letter).count();
    //     let count = occurrences as i32;
    //     count >= self.char_count_min && count <= self.char_count_max
    // }

    pub fn is_valid(&self) -> bool {
        let pos_1 = self.password.chars().nth(self.char_count_min as usize - 1).unwrap();
        let pos_2 = self.password.chars().nth(self.char_count_max as usize - 1).unwrap();

        pos_1 != pos_2 && (pos_1 == self.letter || pos_2 == self.letter)
    }
}
