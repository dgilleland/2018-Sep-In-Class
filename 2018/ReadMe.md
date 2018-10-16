---
title: DMIT 2018 - Intermediate App Dev - Errata
---
# 

> For course notes, see the [Moodle site](https://moodle.nait.ca) or my [online notes](https://DMIT-2018.github.io). For in-class code samples, see the [DMIT 2018 **A01**](https://github.com/dgilleland/2018-Sep-In-Class/tree/DMIT-2018-A01) or [DMIT 2018 **A02**](https://github.com/dgilleland/2018-Sep-In-Class/tree/DMIT-2018-A02) branches on GitHub.

## Ad-Hoc Code Repositories

- ***A01*** [**Temporary Demo**](https://github.com/dgilleland/TemporaryDemo) - An ad-hoc database to practice some git/GitHub commits and to refresh some Entity Framework work from last semester.
- ***A02*** [**TempDemo**](https://github.com/dgilleland/TempDemo) - An ad-hoc database to practice some git/GitHub commits and to refresh some Entity Framework work from last semester.

> I also have some Ad-Hoc code samples of stuff on the [**Ad-Hoc**](https://github.com/dgilleland/2018-Sep-In-Class/tree/AdHoc) branch of my repository for this course.


## LINQ Practice (Ad-Hoc)

See [this](AdHoc.md).

## Flowchart(ish)

```mermaid
graph TB
    c1-->a2
    subgraph one
    a1-->a2
    end
    subgraph two
    b1-->b2
    end
    subgraph three
    c1-->c2
    end
```

## Sequence Diagrams

```mermaid
sequenceDiagram
    Alice->>Bob: Hello Bob, how are you?
    alt is sick
        Bob->>Alice: Not so good :(
    else is well
        Bob->>Alice: Feeling fresh like a daisy
    end
    opt Extra response
        Bob->>Alice: Thanks for asking
    end
```

## Gantt Chart

```mermaid
gantt
        dateFormat  YYYY-MM-DD
        title Adding GANTT diagram functionality to mermaid
        section A section
        Completed task            :done,    des1, 2014-01-06,2014-01-08
        Active task               :active,  des2, 2014-01-09, 3d
        Future task               :         des3, after des2, 5d
        Future task2               :         des4, after des3, 5d
        section Critical tasks
        Completed task in the critical line :crit, done, 2014-01-06,24h
        Implement parser and jison          :crit, done, after des1, 2d
        Create tests for parser             :crit, active, 3d
        Future task in critical line        :crit, 5d
        Create tests for renderer           :2d
        Add to mermaid                      :1d
```
