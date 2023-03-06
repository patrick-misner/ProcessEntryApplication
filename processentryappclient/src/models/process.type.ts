export interface IProcessData {
  id?: number;
  clientRef?: string;
  courtId?: number;
  caseNum?: string;
  priority?: string;
  expireDateTime?: string;
  plaintiffTypeId?: number;
  plaintiff?: string;
  defendantTypeId?: number;
  defendant?: string;
  receivedDateTime?: string;
  documentId?: number;
  ssId?: number;
  instructionId?: number;
  serverId?: number;
  servedDateTime?: string;
  methodId?: number;
  subServed?: string;
  capacityId?: number;
  comments?: string;
  affidavitTypeId?: number;
  serviceFee?: number;
}
