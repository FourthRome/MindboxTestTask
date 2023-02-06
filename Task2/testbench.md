# Task 2: Map Products to Categories

## Assertions

This task has been formulated vaguely (on purpose, I suppose — to see what candidate is familiar with and how they handle indefinite problems).

As far as I know there are wildely unusual ways to make a `product-category` mapping possible in an actual database (I'm thinking of PostgreSQL though, not sure how many options are there in T-SQL).

I'm going for a vanilla **3NF database** example, cause it's five in the morning and I desperately want to apply for the job this Monday. 😂

## Database setup

Let's assume pairs `Product — Category` are stored directly in the database (a natural choice for a m-to-n relationship), with database being initially set up like:
```sql
CREATE TABLE products
(
    product_id INT NOT NULL,
    product VARCHAR (100) NOT NULL,
    CONSTRAINT product_pk PRIMARY KEY (product_id)
);

CREATE TABLE categories
(
    category_id INT NOT NULL,
    category VARCHAR (100) NOT NULL,
    CONSTRAINT category_pk PRIMARY KEY (category_id)
);

CREATE TABLE products_to_categories
(
    product_id INT NOT NULL,
    category_id INT NOT NULL,
    CONSTRAINT product_fk FOREIGN KEY (product_id)
    REFERENCES products (product_id),
    CONSTRAINT category_fk FOREIGN KEY (category_id)
    REFERENCES categories (category_id)
);
```

## The Query™

The solution then is simple:

```sql
SELECT product, category
FROM products
LEFT JOIN products_to_categories
ON products.product_id = products_to_categories.product_id
LEFT JOIN categories
ON products_to_categories.category_id = categories.category_id;
```

Voilà! It would be much harder if the m-to-n relationship was present in some other way though.
