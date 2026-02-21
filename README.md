# Facesso  
### Production Data Acquisition & REFA-Based KPI System  
*(Historical Reference Implementation)*

---

## About Facesso

**Facesso** was originally developed approximately 15 years ago as a production data acquisition and group-based time tracking system for manufacturing environments.

Its core capabilities include:

- REFA-based work value calculations  
- Group-based time tracking  
- KPI computation and bottleneck detection  
- Incentive wage calculation  
- A database-driven integrity model designed to maintain internal consistency  

One of the architecturally notable aspects of Facesso is its SQL integrity layer.  
Even when time or production data is modified directly at the table level, database triggers automatically recalculate KPIs and work-degree metrics to preserve consistency across work groups.

---

## Why This Repository Exists

Facesso is published today as:

- A historical software artifact  
- A realistic enterprise scenario for modernization experiments  
- A non-trivial database integrity case study  
- A practical object for AI-assisted refactoring and migration tooling  
- A learning resource for REFA-based production modeling  

It is intentionally preserved close to its original architectural form to provide a realistic legacy system structure.

---

## Intended Use

You are welcome to:

- Study the architecture  
- Experiment with migration strategies  
- Use it as a test object for AI agents  
- Evaluate modernization approaches  
- Reuse generic UI or printing components  
- Explore REFA-based production modeling  

The goal is to provide something more realistic than a synthetic demo application.

---

## License

Facesso is planned to be released under the MIT License.  
See the `LICENSE` file for details.
