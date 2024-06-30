# SharpTools2024-Documentation

## Namespaces

### `SharpTools2024`
### `SharpTools2024.Exceptions`

## Classes

### `SizeOf`

Contains methods for converting between Bits and Bytes,
and their multipliers,
starting with "Kilo", "Mega", "Giga" and "Tera".

- With the constructor being private,
the initialization has to be done by one of the following methods:
   - `Bits`
   - `KBits` / `KiloBits`
   - `MBits` / `MegaBits`
   - `GBits` / `GigaBits`
   - `TBits` / `TeraBits`
   - `Bytes`
   - `MBytes` / `MegaBytes`
   - `GBytes` / `GigaBytes`
   - `TBytes` / `TeraBytes`
- The initialization syntax is for all the same:
   - `&lt;variable&gt; = SizeOf.&lt;method&gt;(&lt;count&gt;);`

- es geht weiter ...

### `SizeOfException`


