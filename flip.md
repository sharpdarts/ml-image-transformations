# Flip Operations
You can perform the following flip operations with MLIT:
- Horizontal
- Vertical

This is done using the `--flipmodes` argument which is required when invoking the MLIT. The following arguments are accepted, and you must pass at least one in:

- **None**: Do not perform any flip operations
- **Horizontal**: Perform a horizontal flip on the images
- **Vertical**: Perform a vertical flip on the images

These arguments are passed as a space delimited string and **MUST BE** capitalized, for instance:

```
--flipmodes=Vertical Horizontal
```

```
--flipmodes=None
```

## Examples
Consider the following image:

