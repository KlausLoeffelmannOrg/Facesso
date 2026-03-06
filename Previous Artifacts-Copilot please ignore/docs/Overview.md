# What is Facesso

Facesso is a **production data acquisition and incentive wage calculation system** built for manufacturing environments. It tracks how efficiently production teams work and translates that efficiency into bonus wages — all based on the German **REFA** industrial engineering methodology.

In plain terms: workers on a factory floor produce goods. An engineer has previously measured how long each piece of work *should* take. Facesso compares that ideal time against how long workers *actually* spent, and from that ratio calculates a performance-based wage bonus.

---

## What is REFA

**REFA** (originally *Reichsausschuss für Arbeitszeitstudien*, today the *REFA Bundesverband e.V.*) is a German association for Industrial Engineering and Work Organization. Founded in 1924, REFA defines standardized methods for:

- **Time Studies** (*Zeitstudien*) — systematically measuring how long defined work elements take under normal conditions.
- **Work Valuation** (*Arbeitsbewertung*) — assigning standard time values to individual tasks or products.
- **Performance Assessment** (*Leistungsbewertung*) — comparing actual performance to reference norms.

The REFA methodology is widely used in German-speaking manufacturing industries. It provides the scientific foundation that makes incentive wage systems fair and reproducible: everyone is measured against the same objectively established time standards.

---

## Where does the calculation foundation of Facesso come from?

The entire system rests on a simple but powerful chain:

### Step 1 — The REFA Engineer creates Labour Values

A trained REFA engineer conducts **time studies** on the factory floor. For each work element (assembling a part, welding a seam, packing a box), the engineer determines a **standard time** — called **Te** (*Vorgabezeit je Einheit*, target time per unit). These are stored as **Labour Values** (*Arbeitswerte*) in Facesso.

### Step 2 — Production data is recorded per shift

During a shift, the system records:

- **What was produced** — which articles, in what quantities, and which labour values apply to them.
- **Who was working** — which employees were part of the work group, when their shift started/ended, how long their breaks and downtimes were.

### Step 3 — The system calculates the Degree of Time

From those inputs, Facesso computes two key figures:

| Metric | German Term | What it means |
|--------|-------------|---------------|
| **Reference Time** | *Referenz-Belegungszeit* | How long the work **should** have taken — Quantity × Te (labour value) summed across all items produced. |
| **Effective Time** | *Effektive Belegungszeit* | How long the workers **actually** spent — attendance time minus breaks and downtimes, summed across the group. |

The ratio of these two is the **Degree of Time** (*Zeitgrad*):

> **Degree of Time = (Reference Time ÷ Effective Time) × 100 %**

- A value of **100 %** means the team worked exactly at the REFA standard pace.
- A value **above 100 %** means the team was faster than expected.
- A value **below 100 %** means the team was slower.

### Step 4 — Incentive wages are calculated

Each employee has a **Wage Group** (*Lohngruppe*) with an hourly base rate. The bonus wage is then:

> **Bonus = Base Hourly Rate × Effective Hours × (Degree of Time ÷ 100)**

This means: work faster (or more efficiently) than the REFA norm, and you earn more. The incentive is directly tied to measurable, objective productivity.

---

## Key Concepts at a Glance

To work with Facesso (even just as a migration test subject), it helps to know these domain terms:

| English | German (as used in Facesso) | Description |
|---------|-----------------------------|-------------|
| Work Group | *Arbeitsgruppe* | A team of workers at a production site — the primary unit of measurement. |
| Labour Value | *Arbeitswert* | A standard work element with a defined target time (Te). Created from REFA time studies. |
| Time Log | *Zeiterfassung / Schichtdaten* | Per-employee, per-shift record: shift start/end, breaks, downtimes. |
| Production Data | *Produktionsdaten* | Per-work-group, per-shift record of what was produced and the resulting KPIs. |
| Degree of Time | *Zeitgrad* | The core KPI — ratio of reference time to effective time (%). |
| Handicap | *Behinderung* | An adjustment factor (0–100 %) applied when unusual conditions affect productivity (e.g. machine issues, new employees). Reduces effective time proportionally. |
| Wage Group | *Lohngruppe* | Pay classification with an hourly base rate. |
| Bonus List | *Prämienliste* | The computed incentive wages per employee, ready for payroll. |
| Shift | *Schicht* | Work period — typically Shift 1, 2, 3 (early/late/night) or a special shift. |
| Cost Center | *Kostenstelle* | Organizational unit grouping work groups; controls measurement settings. |
| Subsidiary | *Tochtergesellschaft / Niederlassung* | Company or plant — top level of the organizational hierarchy. |

---

## How the Application Works (User Perspective)

### The main screen

The Facesso desktop application opens with a **shell view** containing:

- A **calendar with shift selector** — pick a date and shift (1, 2, 3, or Special) to navigate to a specific production window.
- A **work group list** — showing all production teams for the selected subsidiary and cost center.
- An **employee list** — showing who is assigned to the selected work group.
- A **content area** — displaying production data, time logs, and calculated KPIs for the current selection.

### Typical workflow

1. **Select a date and shift** using the calendar.
2. **Choose a work group** from the list.
3. **Enter or review time data** — shift start/end, breaks, and downtimes for each employee.
4. **Enter or review production data** — which articles were produced, in what quantities, linked to their labour values.
5. **KPIs update automatically** — the Degree of Time and related metrics recalculate whenever any input changes (this happens via database triggers, so even direct SQL edits maintain consistency).
6. **View incentive wage results** on the Bonus List.

### Configuration

Facesso is configured through a separate configuration module (**FacessoConfig**) where administrators set up:

- Subsidiaries and cost centers
- Work groups with their time-setting templates (default shift times, break patterns)
- Labour values and article definitions
- Wage groups and employee assignments
- Database connections and license management

### Data import

The application includes an import tool (**frmTSImportsBeta**) for migrating time study data from legacy Access databases into SQL Server.

---

## Why Facesso is an Interesting Migration Test Subject

For anyone exploring modernization strategies, Facesso offers a realistic, non-trivial legacy system with several challenging characteristics:

| Challenge | What makes it interesting |
|-----------|--------------------------|
| **Language** | Written in VB.NET — ideal for testing VB → C# conversion. |
| **Framework** | Originally targets .NET Framework 2.0 — tests upgrading to modern .NET. |
| **Database logic** | Heavy use of SQL Server **triggers** and **stored procedures** that implement core business logic — tests migrating DB-side logic to application code or EF Core. |
| **Data access** | Uses raw **DataReaders** (no ORM) — tests migrating to Entity Framework Core. |
| **Localization** | All domain terms and UI are in German — tests adding localization/i18n support. |
| **Domain complexity** | Real industrial engineering formulas, group-based aggregation, cascading recalculations — not a toy CRUD app. |
| **Trigger cascades** | Changing one employee's shift time triggers recalculation across the entire work group's KPIs and wage figures — tests preserving complex consistency guarantees during migration. |
