enum Status {
    Pending,
    Processing,
    Shipped,
    Delivered
}

export default Status;

export const statusToString = (status: Status) => {
    switch (status) {
        case Status.Pending:
            return "Afventer";
        case Status.Processing:
            return "Behandles";
        case Status.Shipped:
            return "Afsendt";
        case Status.Delivered:
            return "Leveret";
        default:
            return "Ukendt";
    }
}