const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const userSchema = new Schema({
    Name: String,
    Email: String,
    Street: String,
    City: String,
    Zipcode: Number,
    Tasks: [{title: String, completed: Boolean}],
    Posts: [{title: String, body: String}]
});

module.exports = mongoose.model('Users', userSchema);