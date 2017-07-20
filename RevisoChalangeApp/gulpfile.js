var gulp = require('gulp'),
    sass = require('gulp-sass'),
    browserSync = require('browser-sync');

gulp.task('watch', ['browserSync'], function () {
    gulp.watch('Views/**.cshtml', browserSync.reload);
    gulp.watch('Scripts/**.js', browserSync.reload);

    gulp.watch('Content/scss/**/*.scss', ['sass']);

});


gulp.task('browserSync', function () {
    browserSync.init({
        server: {
            baseDir: 'RevisoChalangeApp'
        },
    })
})



gulp.task('sass', function () {
    return gulp.src('Content/scss/main.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('Content/css'))
        .pipe(browserSync.stream());
});

gulp.task('default', ['sass', 'watch']);