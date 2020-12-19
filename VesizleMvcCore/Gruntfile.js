/// <binding ProjectOpened='watch:views' />
module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/lib/*", "temp/"],
        concat: {
            all: {
                src: ['wwwroot/js/*.js'],
                dest: 'temp/combined.js'
            }
        },
        jshint: {
            files: ['temp/*.js'],
            options: {
                '-W069': false
            }
        },
        uglify: {
            all: {
                src: ['temp/combined.js'],
                dest: 'wwwroot/lib/combined.min.js'
            }
        },
        watch: {
            scripts: {
                files: ['wwwroot/js/*.js', 'temp/*.js'],
                tasks: ['all'],
                options: {
                    spawn: false
                }
            },
            css: {
                files: ['wwwroot/css/*.css'],
                tasks: ['cssmin']
            }
            //,
            //views: {
            //    files: [
            //        'Views/**/*.cshtml',
            //        'wwwroot/js/*.js',
            //        'wwwroot/css/*.css',
            //        'bin/**/*.dll'
            //    ],
            //    options: {
            //        livereload: {
            //            host: 'localhost',
            //            port: 44363,
            //            key: grunt.file.read('path/to/ssl.key'),
            //            cert: grunt.file.read('path/to/ssl.crt')
            //            // you can pass in any other options you'd like to the https server, as listed here: http://nodejs.org/api/tls.html#tls_tls_createserver_options_secureconnectionlistener
            //        }
            //    }
            //}

        },
        cssmin: {
            target: {
                src: ['wwwroot/css/*.css', 'wwwroot/css/!*.min.css'],
                dest: 'wwwroot/lib/vesile.min.css'
            }
        }
    });
    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks('grunt-contrib-jshint');
    grunt.loadNpmTasks('grunt-contrib-concat');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-cssmin');
    grunt.registerTask("all", ['clean', 'concat', 'jshint', 'uglify']);

};
