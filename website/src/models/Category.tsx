enum Category {
    Bats,
    Shoes,
    Balls,
    Clothes,
    Bags,
    Accessories
}

export default Category;

export const categoryToString = (category: Category) => {
    switch (category) {
        case Category.Bats:
            return "Bats";
        case Category.Shoes:
            return "Sko";
        case Category.Balls:
            return "Bolde";
        case Category.Clothes:
            return "Tøj";
        case Category.Bags:
            return "Tasker";
        case Category.Accessories:
            return "Tilbehør";
        default:
            return "Ukendt";
    }
}
