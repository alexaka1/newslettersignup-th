import { HeardAboutUs } from './heard-about-us';

export type NewsletterSignup = {
  email: string;
  other?: string;
  heardAboutUs: HeardAboutUs;
};
