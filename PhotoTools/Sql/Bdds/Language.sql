create table t_culture
(
    id   INTEGER
        constraint t_culture_pk
            primary key autoincrement,
    lang TEXT,
    code varchar(5)
);


INSERT INTO t_culture(lang, code)
VALUES('French', 'fr-FR');
