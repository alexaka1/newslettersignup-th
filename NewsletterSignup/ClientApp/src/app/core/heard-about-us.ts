export const HeardAboutUs = {
  Other: 0,
  Advert: 1,
  WordOfMouth: 2,
} as const;
type ObjectValues<T> = T[keyof T];
export type HEARD_ABOUT_US = keyof typeof HeardAboutUs;
export type HeardAboutUs = ObjectValues<typeof HeardAboutUs>;
