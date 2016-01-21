var gulp = require('gulp');
var inject = require('gulp-inject');
var mainBowerFiles = require('main-bower-files');
var debug = require('gulp-debug');

var config = {
    js: ['!./app/app.module.js',
        '!./app/app.core.module.js',
        './app/*module.js',
        './app/*.js',
        './app/**/*module.js',
        './app/**/*.js']
};

gulp.task('hello-world', function() {
    console.log('Our Hello World');
});

gulp.task('app-scripts', function () {
    return gulp.src('./index.html')
        .pipe(inject(gulp.src(config.js, { read: false }), { name: 'scripts' }))
        .pipe(gulp.dest('./'));
});

gulp.task('bower-scripts', function () {
    return gulp.src('./index.html')
        .pipe(inject(gulp.src(mainBowerFiles(), { read: false }, { relative: true }), { name: 'bower' }))
        .pipe(gulp.dest('./'));
});