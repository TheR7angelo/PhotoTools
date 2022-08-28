create table t_lang
(
    id   INTEGER
        constraint t_lang_pk
            primary key autoincrement,
    lang TEXT
);
INSERT INTO t_lang(lang)
VALUES ('English'), ('French');


create table t_culture
(
    id   INTEGER
        constraint t_culture_pk
            primary key autoincrement
        constraint t_culture_lang_fk
            references t_lang,
    lang INTEGER,
    code VARCHAR(5)
);
INSERT INTO t_culture(lang, code)
VALUES ((SELECT lg.id FROM t_lang lg WHERE lg.lang = 'English'), 'en-EN'),
       ((SELECT lg.id FROM t_lang lg WHERE lg.lang = 'French'), 'fr-FR');

CREATE VIEW v_culture as
SELECT lg.lang, cu.code
FROM t_culture cu
         INNER JOIN t_lang lg
                    on lg.id = cu.id;
