var gulp = require('gulp');
var mainBowerFiles = require('main-bower-files');

var $ = require('gulp-load-plugins')({lazy: true});

var config = {
    temp: './.tmp',

    js: ['!./app/app.module.js',
        '!./app/app.core.module.js',
        './app/*module.js',
        './app/*.js',
        './app/**/*module.js',
        './app/**/*.js'],

    less: './less/*.less'

};

gulp.task('app-scripts', function () {
    return gulp.src('./index.html')
        .pipe($.inject(gulp.src(config.js, { read: false }), { name: 'scripts' }))
        .pipe(gulp.dest('./'));
});

gulp.task('bower-scripts', function () {
    return gulp.src('./index.html')
        .pipe($.inject(gulp.src(mainBowerFiles(), { read: false }, { relative: true }), { name: 'bower' }))
        .pipe(gulp.dest('./'));
});

gulp.task('less-compile', function() {
    return gulp.src(config.less)
        .pipe($.less())
        .pipe($.autoprefixer({ browsers: ['last 2 version', '> 5%'] }))
        .pipe(gulp.dest(config.temp));
});