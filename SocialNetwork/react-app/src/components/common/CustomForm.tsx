import { Box, Button, FormControl, TextInput } from "@primer/react";
import { useState } from "react";

type fieldsType = { [x: string]: any };

export interface ICustomFormProps<TFieldsType extends { [x: string]: any }> {
    fields: TFieldsType,
    clickCallback: (
        fields: TFieldsType,
        setErrorMessage: (text: string) => void
    ) => void,
    buttonText: string
}

export default function CustomForm<TFieldsType extends { [x: string]: any }>(props: ICustomFormProps<TFieldsType>) {

    const [fields, setFields] = useState(props.fields);
    const [errorMessage, setErrorMessage] = useState("");

    const handleSubmit = async (e: any) => {
        e.preventDefault();
        props.clickCallback(fields, setErrorMessage);
    };

    return (
        <Box display="grid" gridGap={3} style={{ width: 250 }}>
            {Object.keys(fields).map((key) =>
                <FormControl key={key}>
                    <FormControl.Label>{key}</FormControl.Label>
                    <TextInput
                        block={true}
                        type="text"
                        value={fields[key]}
                        onChange={(e) => {
                            setFields({
                                ...fields,
                                [key]: e.target.value
                            });
                        }}
                    />
                </FormControl>
            )}

            {errorMessage != "" && (
                <FormControl.Validation variant="error">{errorMessage}</FormControl.Validation>
            )}

            <Button onClick={handleSubmit}>{props.buttonText}</Button>
        </Box>
    );
}