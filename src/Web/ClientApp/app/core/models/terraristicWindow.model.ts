import { ISensorBlock } from "./sensorBlock.model";

export interface ITerraristicWindow{
    id: number;
    name: string;
    creationDate: Date;
    modificationDate: Date;
    apiKey: string;
    // sensorBlocks: ISensorBlock[];
}