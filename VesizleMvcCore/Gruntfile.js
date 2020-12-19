/// <binding ProjectOpened='watch' />
module.exports = function (grunt) {
    grunt.initConfig({
        clean: ["wwwroot/lib/*", "temp/"],
        concat: {
            dist: {
                src: ['wwwroot/js/*.js'],
                dest: 'temp/combined.js'
            }
        },
        jshint: {
            files: ['temp/*.js'],
            options: {
                '-W069': false,
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
                files: ['wwwroot/js/*.js'],
                tasks: ['all'],
                options: {
                    spawn: false
                }
            },
            css: {
                files: ['wwwroot/css/*.css'],
                tasks: ['all']
            }
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
    grunt.registerTask("all", ['clean', 'concat', 'jshint', 'uglify', 'cssmin']);

};
