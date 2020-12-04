use std::fmt::{Display, Formatter, Result};

pub struct PassportCredentials {
    pub birth_year: u32,
    pub issue_year: u32,
    pub exp_year: u32,
    pub height: f64,
    pub hair_color: String,
    pub eye_color: String,
    pub passport_id: String,
    pub country_id: String,
}

impl Display for PassportCredentials {
    fn fmt(&self, f: &mut Formatter) -> Result {
        write!(f, "birth year: {}\nissue year: {}\nexp year: {}\nheight: {}\nhair color: {}\neye color: {}\npassport id: {}\ncountry id: {}", 
        self.birth_year, self.issue_year, self.exp_year, self.height, self.hair_color, self.eye_color, self.passport_id, self.country_id)
    }
}
