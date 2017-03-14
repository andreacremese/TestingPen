'use strict';
var _sut = require('./../library.js');
var chai = require('chai');
var expect = chai.expect;

chai.should();

describe('isEven', function () {
    it ('should return if the number is even', function () {
        _sut.isEven(4).should.be.true;
    })
});